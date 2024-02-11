import { CommonModule } from "@angular/common";
import { Component, OnInit } from "@angular/core";
import { RouterModule } from "@angular/router";
import { Store } from "@ngrx/store";
import { setJobs } from "./store/job.actions";
import { Job, jobSelector, JobState } from "./store/job.reducer";

import { ChartType, Column, GoogleChartsModule } from "angular-google-charts";

import { JobsService } from "./services/jobs.service";
import { HttpClientModule } from "@angular/common/http";
import { Observable } from "rxjs";

@Component({
  selector: "app-root",
  standalone: true,
  imports: [CommonModule, RouterModule, GoogleChartsModule, HttpClientModule],
  providers: [JobsService],
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"],
})
export class AppComponent implements OnInit {
  jobs$: Observable<Job[]>;

  constructor(
    private store: Store<JobState>,
    private service: JobsService
  ) {
    this.jobs$ = store.select(jobSelector);
  }

  data: any = [];
  type: ChartType = ChartType.LineChart;

  options: any = {
    title: "Cumulative Job Views vs. Predicted",
    curveType: "function",
    legend: { position: "bottom" },
    vAxis: {
      title: "Job Views",
      type: "number",
    },
    hAxis: {
      type: "date",
      format: "MMM dd",
    },
    pointSize: 5,
    tooltip: { isHtml: true, trigger: "selection" },
    colors: ["silver", "green", "blue"],
    seriesType: "line",
    series: {
      0: {
        type: "bars",
      },
    },
  };

  columns: Column[] = [
    {
      label: "Date",
      type: "date",
    },
    {
      label: "Active jobs",
      type: "number",
    },
    {
      label: "Cumulative job views",
      type: "number",
    },
    {
      label: "Cumulative predicted job views",
      type: "number",
    },
  ];

  ngOnInit(): void {    
    this.jobs$.subscribe(jobs => {
      this.data = jobs.map((job:Job) => [new Date(job.date), job.totalJobs, job.totalViews, job.predictedViews])
    });

    this.service.getData().subscribe(jobs => {
      return this.store.dispatch(setJobs(jobs))
    });
  }
}

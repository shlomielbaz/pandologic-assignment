import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { appConfig } from '../app.config';
import { Job } from '../store/job.reducer';

@Injectable({
  providedIn: 'root'
})
export class JobsService {

  constructor(private http: HttpClient) { }

  getData(): Observable<Job[]> {
    return this.http.get<Job[]>(`${appConfig.apiUrl}/api/jobs`);
  }
}

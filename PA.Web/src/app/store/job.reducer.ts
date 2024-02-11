import { createReducer, createSelector, on } from '@ngrx/store';
import { addJob, getJobs, setJobs } from './job.actions';

export interface JobState {
  jobs: Job[];
}

export interface Job {
  id: number;
  date: Date;
  totalJobs: number;
  totalViews: number;
  predictedViews: number;
}


const initialState: Job[] = [];

export const jobReducer = createReducer(
  initialState,
  on(getJobs, (state, { jobs }) => [...state]),
  on(setJobs, (state, { jobs }) => [...jobs]),
  on(addJob, (state, { job }) => [...state, job])
);

export const jobSelector = createSelector(
  (state: JobState) => state.jobs,
  (jobs) => jobs
);

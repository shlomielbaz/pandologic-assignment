import { createAction } from '@ngrx/store';
import { Job } from './job.reducer';

export const addJob = createAction('[Job] Add Job', (job: Job) => ({job}));

export const getJobs = createAction('[Jobs] Get Jobs', (jobs: Job[]) => ({jobs}));

export const setJobs = createAction('[Jobs] Set Jobs', (jobs: Job[]) => ({  jobs}));

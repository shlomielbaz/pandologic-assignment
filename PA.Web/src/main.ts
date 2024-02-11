import { bootstrapApplication } from '@angular/platform-browser';
import { provideStore } from '@ngrx/store';
import { AppComponent } from './app/app.component';
import { jobReducer } from './app/store/job.reducer';


bootstrapApplication(AppComponent, {
  providers: [
    provideStore({ jobs: jobReducer })
  ],
}).catch((err: any) => console.error(err));

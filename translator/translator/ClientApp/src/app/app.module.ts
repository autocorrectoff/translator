import { TranslatorBackendService } from './services/translator-backend.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Route, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { ResultPageComponent } from './result-page/result-page.component';
import { LandingPageComponent } from './landing-page/landing-page.component';

const routes: Routes = [
  { path: 'result-page', component: ResultPageComponent },
  { path: 'landing-page', component: LandingPageComponent },
  { path: '', redirectTo: '/landing-page', pathMatch: 'full' },
  { path: '**', redirectTo: '/landing-page'}
];


@NgModule({
  declarations: [
    AppComponent,
    ResultPageComponent,
    LandingPageComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(routes)
  ],
  providers: [TranslatorBackendService],
  bootstrap: [AppComponent]
})
export class AppModule { }


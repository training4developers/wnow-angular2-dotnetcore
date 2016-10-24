import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule, XHRBackend, RequestOptions } from '@angular/http';
import { FormsModule } from '@angular/forms';

import '../../css/styles.scss';

import { AppComponent, ConsoleLogPipe, SpanDirective } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { StudentListComponent } from './components/student-list/student-list.component';

import { AppStorage } from './services/app-storage';
import { Account } from './services/account';
import { AuthorizedHttp } from './services/authorized-http';
import { Students } from './services/students';

@NgModule({
	imports: [ BrowserModule, HttpModule, FormsModule ],
	declarations: [ AppComponent, LoginComponent, StudentListComponent, ConsoleLogPipe, SpanDirective ],
	providers: [
		Account, AppStorage, Students,
	  {
			provide: AuthorizedHttp,
			useFactory: (appStorage: AppStorage, backend: XHRBackend, defaultOptions: RequestOptions) =>
				new AuthorizedHttp(appStorage, backend, defaultOptions),
			deps: [AppStorage, XHRBackend, RequestOptions]
		}
	],
	bootstrap: [ AppComponent ]
})
export class AppModule { }
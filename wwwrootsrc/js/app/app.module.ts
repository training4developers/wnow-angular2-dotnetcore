import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule, XHRBackend, RequestOptions } from '@angular/http';
import { FormsModule } from '@angular/forms';

import '../../css/styles.scss';

import { AppRouterModule } from './app.router';

import { AppComponent } from './app.component';
import { HomePageComponent } from './components/home-page/home-page.component';
import { WidgetToolComponent } from './components/widget-tool/widget-tool.component';
import { UserLoginComponent } from './components/user-login/user-login.component';
import { WidgetListComponent } from './components/widget-list/widget-list.component';

import { AppStorage } from './services/app-storage';
import { Account } from './services/account';
import { AuthorizedHttp } from './services/authorized-http';
import { Widgets } from './services/widgets';

@NgModule({
	imports: [ BrowserModule, HttpModule, FormsModule, AppRouterModule ],
	declarations: [
		AppComponent, HomePageComponent, WidgetToolComponent,
		UserLoginComponent, WidgetListComponent
	],
	providers: [
		Account, AppStorage, Widgets,
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
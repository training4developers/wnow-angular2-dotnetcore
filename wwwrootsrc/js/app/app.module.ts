import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule, XHRBackend, RequestOptions } from '@angular/http';
import { FormsModule } from '@angular/forms';

import '../../css/styles.scss';

import { AppRouterModule } from './app.router';

import { AppComponent } from './app.component';
import { PageHeaderComponent } from './components/page-header/page-header.component';
import { PageFooterComponent } from './components/page-footer/page-footer.component';
import { HomePageComponent } from './components/home-page/home-page.component';
import { WidgetToolComponent } from './components/widget-tool/widget-tool.component';
import { UserLoginComponent } from './components/user-login/user-login.component';
import { WidgetListComponent } from './components/widget-list/widget-list.component';
import { WidgetViewComponent } from './components/widget-view/widget-view.component';
import { WidgetEditComponent } from './components/widget-edit/widget-edit.component';

import { AppStorage } from './services/app-storage';
import { Account } from './services/account';
import { AuthorizedHttp } from './services/authorized-http';
import { Widgets } from './services/widgets';

@NgModule({
	imports: [ BrowserModule, HttpModule, FormsModule, AppRouterModule ],
	declarations: [
		AppComponent, PageHeaderComponent, PageFooterComponent, HomePageComponent, UserLoginComponent,
		WidgetToolComponent, WidgetListComponent, WidgetViewComponent, WidgetEditComponent
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
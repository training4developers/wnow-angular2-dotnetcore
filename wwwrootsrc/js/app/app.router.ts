import { Route, RouterModule } from '@angular/router';

import { HomePageComponent } from './components/home-page/home-page.component';
import { WidgetToolComponent } from './components/widget-tool/widget-tool.component';
import { WidgetListComponent } from './components/widget-list/widget-list.component';
import { WidgetViewComponent } from './components/widget-view/widget-view.component';
import { WidgetEditComponent } from './components/widget-edit/widget-edit.component';

const appRoutes: Route[] = [
	{ path: '', component: HomePageComponent },
	{ 
		path: 'widget-tool',
		component: WidgetToolComponent,
		children: [
			{ path: '', component: WidgetListComponent },
			{ path: 'widget/create', component: WidgetEditComponent },
			{ path: 'widget/:widgetId', component: WidgetViewComponent },
			{ path: 'widget/:widgetId/edit', component: WidgetEditComponent }
		]
	}
];

export const AppRouterModule = RouterModule.forRoot(appRoutes, { useHash: false });	
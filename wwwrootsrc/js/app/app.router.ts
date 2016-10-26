import { Route, RouterModule } from '@angular/router';

import { HomePageComponent } from './components/home-page/home-page.component';
import { WidgetToolComponent } from './components/widget-tool/widget-tool.component';
import { WidgetListComponent } from './components/widget-list/widget-list.component';

const appRoutes: Route[] = [
	{ path: '', component: HomePageComponent },
	{
		path: 'widget-tool',
		component: WidgetToolComponent,
		children: [
			{ path: '', component: WidgetListComponent },
		]
	}
];

export const AppRouterModule = RouterModule.forRoot(appRoutes, { useHash: false });	
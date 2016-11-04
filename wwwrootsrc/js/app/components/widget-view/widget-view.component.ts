import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Widgets } from '../../services/widgets';
import { Widget } from '../../models/widget';

@Component({
	selector: 'widget-view',
	template: require('./widget-view.component.html'),
	styles: [require('./widget-view.component.scss')],
})
export class WidgetViewComponent implements OnInit {

	widget: Widget;

	constructor(
		private router: Router,
		private route: ActivatedRoute,
		private widgets: Widgets
	) { }

	ngOnInit() {
		this.route.params.subscribe(params => {
			this.widgets.get(params['widgetId']).subscribe(widget => {
				this.widget = widget;
			})
		});
	}

	editWidget(widgetId: number) {
		this.router.navigateByUrl(`/widget-tool/widget/${widgetId}/edit`);
	}

	returnToList() {
		this.router.navigateByUrl(`/widget-tool`);
	}
}
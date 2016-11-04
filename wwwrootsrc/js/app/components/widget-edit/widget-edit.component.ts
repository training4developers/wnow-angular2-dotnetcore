import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Widgets } from '../../services/widgets';
import { Widget } from '../../models/widget';

@Component({
	selector: 'widget-edit',
	template: require('./widget-edit.component.html'),
	styles: [require('./widget-edit.component.scss')],
})
export class WidgetEditComponent implements OnInit {

	widget: Widget = <Widget>{
		id: 0,
		name: '',
		description: '',
		color: '',
		size: '',
		quantity: 0,
		price: 0
	};

	constructor(
		private router: Router,
		private route: ActivatedRoute,
		private widgets: Widgets
	) { }

	ngOnInit() {
		this.route.params.subscribe(params => {
			if (params['widgetId']) {
				this.widgets.get(params['widgetId']).subscribe(widget => {
					this.widget = widget;
				});
			}
		});
	}

	saveWidget(widget: Widget) {

		const widgetsObservable = widget.id
			? this.widgets.update(widget)
			: this.widgets.insert(widget);

		widgetsObservable.subscribe(() => {
			this.router.navigateByUrl('/widget-tool');
		});
	}

	deleteWidget(widgetId: number) {
		this.widgets.delete(widgetId).subscribe(() => {
			this.router.navigateByUrl('/widget-tool');
		});
	}

	returnToList() {
		this.router.navigateByUrl('/widget-tool');
	}	
}
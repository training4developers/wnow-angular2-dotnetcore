import { Component, OnInit } from '@angular/core';

import { Widgets } from '../../services/widgets';
import { Widget } from '../../models/widget';

@Component({
	selector: 'widget-list',
	template: require('./widget-list.component.html'),
	styles: [require('./widget-list.component.scss')]
})
export class WidgetListComponent implements OnInit {

	widgetList: Widget[] = [];

	constructor(private widgets: Widgets) { }

	ngOnInit() {
		this.widgets.getAll().subscribe(widgets => {
			this.widgetList = widgets;
		});
	}
}
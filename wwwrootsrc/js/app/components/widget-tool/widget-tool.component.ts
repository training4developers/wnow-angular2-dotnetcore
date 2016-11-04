import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { BaseAuthorizedComponent } from '../base-authorized-component';
import { AppStorage } from '../../services/app-storage';

@Component({
	selector: 'widget-tool',
	template: require('./widget-tool.component.html'),
	styles: [require('./widget-tool.component.scss')]
})
export class WidgetToolComponent extends BaseAuthorizedComponent {

	constructor(router: Router, appStorage: AppStorage) {
		super(router, appStorage);
	}

}
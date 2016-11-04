import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { AppStorage } from '../../services/app-storage';

@Component({
	selector: 'home-page',
	template: require('./home-page.component.html'),
	styles: [require('./home-page.component.scss')]
})
export class HomePageComponent {

	loggedIn: boolean = false;

	constructor(private appStorage: AppStorage, private router: Router) { }

	loginSuccess() {
		this.loggedIn = true;
		this.router.navigateByUrl('/widget-tool');
	}
	
}
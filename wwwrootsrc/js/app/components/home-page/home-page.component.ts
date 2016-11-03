import { Component } from '@angular/core';
import { DomSanitizer, SafeStyle } from '@angular/platform-browser'; 
import { Router } from '@angular/router';

import { AppStorage } from '../../services/app-storage';

@Component({
	selector: 'home-page > div.test-comp',
	template: 'TestComp5'
})
export class TestComponent {

}

@Component({
	selector: 'home-page > div:not(.test-comp)',
	template: 'Test2Comp5'
})
export class Test2Component {

}

@Component({
	selector: 'home-page',
	template: require('./home-page.component.html'),
	styles: [require('./home-page.component.scss')]
})
export class HomePageComponent {

	loggedIn: boolean = false;

	textColor: SafeStyle;
	classNames: string = 'first-class second-class';

	constructor(private appStorage: AppStorage, private router: Router, private domSanitizer: DomSanitizer) {
		this.textColor = domSanitizer.bypassSecurityTrustStyle('blue');
	}

	loginSuccess() {
		console.log('authToken: ' + this.appStorage.get('AuthToken'));
		this.loggedIn = true;
		this.router.navigateByUrl('/widget-tool');
	}
	
}
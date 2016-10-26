import { Component } from '@angular/core';
import { AppStorage } from './services/app-storage';

@Component({
	selector: 'main',
	styles: [require('./app.component.scss')],
	template: require('./app.component.html'),
	exportAs: 'AppComponent'
})
export class AppComponent { }
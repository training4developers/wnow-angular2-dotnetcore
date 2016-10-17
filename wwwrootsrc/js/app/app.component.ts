import { Component } from '@angular/core';

@Component({
	selector: 'web-app',
	styles: [require('./app.component.scss')],
	template: require('./app.component.html')
})
export class AppComponent {
	message: string = 'Hello World!';
}
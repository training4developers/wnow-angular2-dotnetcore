import { Component, Directive, Pipe, PipeTransform } from '@angular/core';
import { AppStorage } from './services/app-storage';

@Pipe({ name: 'consoleLog' })
export class ConsoleLogPipe implements PipeTransform {

	transform(value: any) {
		console.dir(value);
		return value;
	}
}

@Directive({
	selector: 'span',
	exportAs: 'mySpan'
})
export class SpanDirective {
	doIt() { }
}

@Component({
	selector: 'web-app',
	styles: [require('./app.component.scss')],
	template: require('./app.component.html'),
	exportAs: 'AppComponent'
})
export class AppComponent {

	loggedIn: boolean = false;

	constructor(private appStorage: AppStorage) { }

	loginSuccess() {
		console.log('authToken: ' + this.appStorage.get('AuthToken'));
		this.loggedIn = true;
	}

}
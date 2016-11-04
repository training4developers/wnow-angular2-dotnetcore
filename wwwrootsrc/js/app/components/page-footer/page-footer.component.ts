import { Component } from '@angular/core';

@Component({
	selector: 'main > footer',
	template: require('./page-footer.component.html'),
	styles: [require('./page-footer.component.scss')]
})
export class PageFooterComponent {

	currentDate: Date = new Date();
}
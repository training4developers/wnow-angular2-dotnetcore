import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';

interface Student {
	id: number,
	firstName: string,
	lastName: string
}

@Component({
	selector: 'web-app',
	styles: [require('./app.component.scss')],
	template: require('./app.component.html')
})
export class AppComponent implements OnInit {

	message: string = 'Hello World!';
	students: Student[] = [];

	constructor(private http: Http) {

	}

	ngOnInit() {

		this.http.get('students').subscribe(res => {
			this.students = res.json();
		});

	}

}
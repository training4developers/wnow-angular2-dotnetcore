import { Component, OnInit } from '@angular/core';

import { Students } from '../../services/students';
import { Student } from '../../models/student';

@Component({
	selector: 'student-list',
	template: require('./student-list.component.html'),
	styles: [require('./student-list.component.scss')]
})
export class StudentListComponent implements OnInit {

	studentList: Student[] = [];

	constructor(private students: Students) { }

	ngOnInit() {
		this.students.getAll().subscribe(students => {
			this.studentList = students;
		});
	}
}
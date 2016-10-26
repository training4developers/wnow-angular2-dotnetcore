import { Injectable } from '@angular/core';
import { Headers } from '@angular/http';

import { Observable } from 'rxjs';

import { AuthorizedHttp } from './authorized-http';
import { Widget } from '../models/widget';

@Injectable()
export class Widgets {

	constructor(private http: AuthorizedHttp) { }

	getAll(): Observable<Widget[]> {
		return this.http.get('/widgets').map(res => res.json());
	}

	get(widgetId: number): Observable<Widget> {
		return this.http.get(`/widgets/${encodeURIComponent(widgetId.toString())}`)
			.map(res => res.json());
	}

	insert(widget: Widget): Observable<Widget> {
		return this.http.post(`/widgets`, JSON.stringify(widget),
			new Headers({ 'Content-Type': 'application/json' })).map(res => res.json());
	} 

	update(widget: Widget): Observable<Widget> {
		return this.http.put(`/widgets/${encodeURIComponent(widget.id.toString())}`,
			JSON.stringify(widget), new Headers({ 'Content-Type': 'application/json' }))
				.map(res => res.json());
	} 

	delete(widgetId: number): Observable<Widget> {
		return this.http.delete(`/widgets/${encodeURIComponent(widgetId.toString())}`)
			.map(res => res.json());
	} 
}
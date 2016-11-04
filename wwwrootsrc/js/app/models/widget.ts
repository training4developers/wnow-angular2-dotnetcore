import { Element } from './element';

export interface Widget extends Element {
	id: number;
	name: string;
	description: string;
	color: string;
	size: string;
	quantity: number;
	price: number;
}
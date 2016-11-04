import { Element } from './element';

export interface User extends Element {

	id: number;
	firstName: string;
	lastName: string;
	emailAddress: string;

}
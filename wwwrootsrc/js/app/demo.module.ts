import { NgModule, Component, ViewEncapsulation, ChangeDetectionStrategy } from '@angular/core';

@Component({
	selector: 'demo-comp',
	template: '<span>DemoComp</span>',
	changeDetection: ChangeDetectionStrategy.OnPush
})
export class DemoComp {

}

@NgModule({
	declarations: [ DemoComp ],
	exports: [ DemoComp ]
})
export class DemoModule {
}
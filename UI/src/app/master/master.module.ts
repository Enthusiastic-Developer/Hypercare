import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'

import { MasterRoutingModule } from './master-routing.module'
import { MasterHomeComponent } from './master-home/master-home.component'
import { SharedModule } from '../shared/shared.module'

@NgModule({
  declarations: [MasterHomeComponent],
  imports: [CommonModule, MasterRoutingModule, SharedModule]
})
export class MasterModule { }

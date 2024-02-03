import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'

import { MapperRoutingModule } from './mapper-routing.module'
import { MapperHomeComponent } from './mapper-home/mapper-home.component'

@NgModule({
  declarations: [MapperHomeComponent],
  imports: [
    CommonModule,
    MapperRoutingModule
  ]
})
export class MapperModule { }

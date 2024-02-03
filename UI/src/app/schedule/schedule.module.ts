import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'

import { ScheduleRoutingModule } from './schedule-routing.module'
import { ScheduleHomeComponent } from './schedule-home/schedule-home.component'

@NgModule({
  declarations: [ScheduleHomeComponent],
  imports: [CommonModule, ScheduleRoutingModule]
})
export class ScheduleModule {}

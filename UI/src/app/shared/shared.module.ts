import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'

import { SharedRoutingModule } from './shared-routing.module'
import { NotfoundComponent } from './notfound/notfound.component'
import { TableComponent } from './table/table.component'
import { UnauthorizedComponent } from './unauthorized/unauthorized.component'

@NgModule({
  declarations: [NotfoundComponent, TableComponent, UnauthorizedComponent],
  imports: [CommonModule, SharedRoutingModule]
})
export class SharedModule {}

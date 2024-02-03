import { NgModule } from '@angular/core'
import { RouterModule, type Routes } from '@angular/router'
import { MapperHomeComponent } from './mapper-home/mapper-home.component'

const routes: Routes = [
  {
    path: '',
    component: MapperHomeComponent
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MapperRoutingModule {}

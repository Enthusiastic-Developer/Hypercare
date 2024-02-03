import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { LayoutComponent } from './layout.component'
import { FooterComponent } from './footer/footer.component'
import { HeaderComponent } from './header/header.component'

@NgModule({
  imports: [CommonModule],
  declarations: [LayoutComponent, FooterComponent, HeaderComponent],
  exports: [FooterComponent, HeaderComponent]
})
export class LayoutModule {}

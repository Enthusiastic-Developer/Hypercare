import { ComponentFixture, TestBed } from '@angular/core/testing'

import { MapperHomeComponent } from './mapper-home.component'

describe('MapperHomeComponent', () => {
  let component: MapperHomeComponent
  let fixture: ComponentFixture<MapperHomeComponent>

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MapperHomeComponent],
    }).compileComponents()

    fixture = TestBed.createComponent(MapperHomeComponent)
    component = fixture.componentInstance
    fixture.detectChanges()
  })

  it('should create', () => {
    expect(component).toBeTruthy()
  })
})

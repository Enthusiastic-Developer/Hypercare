import { type ComponentFixture, TestBed } from '@angular/core/testing'

import { ScheduleHomeComponent } from './schedule-home.component'

describe('ScheduleHomeComponent', () => {
  let component: ScheduleHomeComponent
  let fixture: ComponentFixture<ScheduleHomeComponent>

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ScheduleHomeComponent]
    })
      .compileComponents()

    fixture = TestBed.createComponent(ScheduleHomeComponent)
    component = fixture.componentInstance
    fixture.detectChanges()
  })

  it('should create', () => {
    expect(component).toBeTruthy()
  })
})

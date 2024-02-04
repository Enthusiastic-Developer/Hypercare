import { ComponentFixture, TestBed } from '@angular/core/testing'
import { HistoryHomeComponent } from './history-home.component'

describe('HistoryHomeComponent', () => {
  let component: HistoryHomeComponent
  let fixture: ComponentFixture<HistoryHomeComponent>

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HistoryHomeComponent], // Use 'declarations' instead of 'imports'
    }).compileComponents()

    fixture = TestBed.createComponent(HistoryHomeComponent)
    component = fixture.componentInstance
    fixture.detectChanges()
  })

  it('should create', () => {
    expect(component).toBeTruthy()
  })
})

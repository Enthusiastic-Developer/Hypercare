import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Observable } from 'rxjs'
import { environment } from 'src/environments/environment';
import { APIController } from '../constants/common.constants';
import { HyperCareTaskMaster } from '../Interfaces/HyperCareTaskMaster.';

@Injectable({
  providedIn: 'root'
})
export class CareOpsService {
  public constructor(private readonly http: HttpClient) { }

  public GetAllCareOps(): Observable<HyperCareTaskMaster> {
    return this.http.get<HyperCareTaskMaster>(environment.URLS.CareOpsURL + APIController.GetCareOps)
  }
  /**
   * NewOpsdata
taskid: number,deletedby: string   */
  public NewOpsdata(taskid: number, deletedby: string) {
    return this.http.post(environment.URLS.CareOpsURL + APIController.AddCareOpsManager, { taskid, deletedby })
  }
}

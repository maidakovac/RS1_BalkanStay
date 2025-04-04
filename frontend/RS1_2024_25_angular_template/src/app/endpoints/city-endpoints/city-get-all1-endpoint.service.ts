import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface CityGetAll1Response {
  id: number;
  name: string;
  countryName: string;
}

@Injectable({
  providedIn: 'root'
})
export class CityGetAll1EndpointService implements MyBaseEndpointAsync<void, CityGetAll1Response[]> {
  private apiUrl = `${MyConfig.base_url}/cities/all`;

  constructor(private httpClient: HttpClient) {
  }

  handleAsync() {
    return this.httpClient.get<CityGetAll1Response[]>(`${this.apiUrl}`);
  }
}

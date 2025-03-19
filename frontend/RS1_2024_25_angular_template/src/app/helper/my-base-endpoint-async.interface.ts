import { Observable } from 'rxjs';

export interface MyBaseEndpointAsync<TRequest = void, TResponse = any> {
  handleAsync(request: TRequest): Observable<TResponse>;
}

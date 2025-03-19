import {MyAuthInfo} from "./my-auth-info";

export interface LoginTokenDto {
  accountID: number;
  userId: any;
  requires2FA: boolean;
  myAuthInfo: MyAuthInfo | null;
  token: string;
}

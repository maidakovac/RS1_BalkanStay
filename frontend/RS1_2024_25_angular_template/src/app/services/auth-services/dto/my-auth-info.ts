// DTO to hold authentication information
export interface MyAuthInfo {
  userId: number;
  username: string;
  firstName: string;
  lastName: string;
  isAdmin: boolean;
  isOwner: boolean;
  isLoggedIn: boolean;
  slikaPath?: any;
}

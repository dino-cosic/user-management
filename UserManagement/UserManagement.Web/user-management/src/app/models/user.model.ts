import { Status } from './enums/status.enum';

export class User {
  id: number;
  firstName: string;
  lastName: number;
  email: string;
  username: number;
  password: string;
  status: Status;

  public constructor(init?: Partial<User>) {
    Object.assign(this, init);
  }
}

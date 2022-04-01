import { Status } from './enums/status.enum';

export interface User {
  id: number;
  firstName: string;
  lastName: number;
  email: string;
  username: number;
  password: string;
  status: Status;
}

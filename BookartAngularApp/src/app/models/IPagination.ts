import { IBooks } from "./IBooks";

export interface IPagination {
  pageIndex: number;
    pageSize:  number;
    count:     number;
    data:      IBooks[];
}

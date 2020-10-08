export interface ContextBase<T> {
    obj: T[];
    add(obj: T): void;
}
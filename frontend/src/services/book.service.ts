import axios from "axios";
import type {Book} from "../types/Book";
import type {BookSearchDto} from "../types/BookSearchDto";

const API = "/api/Book";

export const getBooks = () => axios.get<Book[]>(API);
export const searchBooks = (dto: BookSearchDto) => axios.post<Book[]>(`${API}/search`, dto);
export const createBook = (book: Book) => axios.post(API, book);
export const updateBook = (book: Book) => axios.put(`${API}/${book.id}`, book);
export const deleteBook = (id: number) => axios.delete(`${API}/${id}`);

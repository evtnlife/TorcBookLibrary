import {useEffect, useState} from "react";
import * as api from "../services/book.service";
import type {Book} from "../types/Book";
import type {BookSearchDto} from "../types/BookSearchDto";

export const useBooks = () => {
	const [books, setBooks] = useState<Book[]>([]);
	const [editing, setEditing] = useState<Book | null>(null);

	const fetchBooks = async () => {
		const {data} = await api.getBooks();
		setBooks(data);
	};

	const searchBooks = async (dto: BookSearchDto) => {
		const {data} = await api.searchBooks(dto);
		setBooks(data);
	};

	const createBook = async (book: Book) => {
		await api.createBook(book);
		await fetchBooks();
	};

	const updateBook = async (book: Book) => {
		await api.updateBook(book);
		await fetchBooks();
		setEditing(null);
	};

	const deleteBook = async (id: number) => {
		await api.deleteBook(id);
		await fetchBooks();
	};

	useEffect(() => {
		fetchBooks();
	}, []);

	return {
		books,
		editing,
		setEditing,
		fetchBooks,
		searchBooks,
		createBook,
		updateBook,
		deleteBook,
	};
};

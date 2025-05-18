import {useState} from "react";
import {BookForm} from "../components/BookForm";
import {BookSearch} from "../components/BookSearch";
import {BookTable} from "../components/BookTable";
import {useBooks} from "../hooks/useBooks";
import {Button, Stack, Box} from "@mui/material";
import type {BookSearchDto} from "../types/BookSearchDto";

const BookList = () => {
	const {books, editing, setEditing, createBook, updateBook, searchBooks, deleteBook} = useBooks();
	const [search, setSearch] = useState<BookSearchDto>({});
	const [showForm, setShowForm] = useState(false);

	const handleEdit = (book: any) => {
		setEditing(book);
		setShowForm(true);
	};

	const handleDelete = (book: any) => {
		deleteBook(book.id);
		setShowForm(false);
	};

	const handleCancel = () => {
		setEditing(null);
		setShowForm(false);
	};

	const handleSubmit = (book: any) => {
		if (editing) updateBook(book);
		else createBook(book);
		setShowForm(false);
	};

	return (
		<Box sx={{display: "flex", justifyContent: "center"}}>
			<Box>
				{!showForm && (
					<Box>
						<BookSearch search={search} setSearch={setSearch} onSearch={() => searchBooks(search)} />
						<Stack direction="row" justifyContent="flex-end" sx={{width: "100%"}}>
							<Button variant="contained" onClick={() => setShowForm(true)}>
								Add Book
							</Button>
						</Stack>
					</Box>
				)}

				{showForm && (
					<Box width="100%" maxWidth="600px">
						<BookForm book={editing || undefined} onSubmit={handleSubmit} onCancel={handleCancel} />
					</Box>
				)}

				{!showForm && <BookTable books={books} onEdit={handleEdit} onDelete={handleDelete} />}
			</Box>
		</Box>
	);
};

export default BookList;

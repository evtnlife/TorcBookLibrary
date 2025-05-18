import BookList from "./pages/BookList";
import {Container, Typography} from "@mui/material";

export default function App() {
	return (
		<Container>
			<Typography variant="h4" sx={{textAlign: "center", marginTop: "30px", marginBottom: "30px"}} gutterBottom>
				My Book Library
			</Typography>
			<BookList />
		</Container>
	);
}

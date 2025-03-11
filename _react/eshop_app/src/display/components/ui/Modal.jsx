import { createPortal } from "react-dom"

const Modal = ({ children, closeModal }) => {

	return createPortal(
		<div id="modal">
			<div className="modal_content">
				{children}
				<button className="btn btn_close" onClick={closeModal}>Fermer</button>
			</div>
		</div>,
		document.body
	)
}

export default Modal;
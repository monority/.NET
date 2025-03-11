import { createPortal } from "react-dom"

const Modal = ({ children, closeModal }) => {

	return createPortal(
		<div id="modal">
			<div className="modal_container">
				<div className="modal_title">
					<div className="element">
						<h1>Cart</h1>
					</div>
					<div className="element">
						<button className="btn_modal" onClick={closeModal}>X</button>
					</div>
				</div>
				<div className="modal_content">
					{children}
				</div>
			</div>
		</div>,
		document.body
	)
}

export default Modal;
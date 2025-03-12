import { useEffect } from "react"
import { createPortal } from "react-dom"

const Modal = ({ children, closeModal }) => {
	const detectEscape = (e) => {
		if (e.key === 'Escape') {
			closeModal()
		}
	}
	useEffect(() => {
		document.addEventListener('keydown', detectEscape)
		return () => {
			document.removeEventListener('keydown', detectEscape)
		}
	}
		, [])
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
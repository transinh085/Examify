import { Footer as FooterAnt } from "antd/es/layout/layout";

const FooterAdmin = () => {
  return (
    <FooterAnt className="text-center">
      Copyright © {new Date().getFullYear()} Ticket Booking
    </FooterAnt>
  );
};

export default FooterAdmin;

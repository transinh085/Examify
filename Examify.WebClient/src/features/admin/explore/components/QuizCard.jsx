import { Card } from "antd";

const { Meta } = Card;

const QuizCard = ({ imageUrl, title, description }) => (
  <Card
    hoverable
    className="w-full"
    cover={
      <img 
        alt={title} 
        className="h-40 sm:h-[200px] object-cover"
        src={imageUrl}
        loading="lazy"
      />
    }
  >
    <Meta 
      title={<div className="truncate">{title}</div>}
      description={<div className="truncate">{description}</div>}
    />
  </Card>
);

export default QuizCard;
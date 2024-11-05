import { useEffect, useState } from 'react';
import { DeleteOutlined, LoadingOutlined, PlusOutlined } from '@ant-design/icons';
import { Button, message, Space, Upload } from 'antd';
import { useUploadImageMutation } from '~/features/quiz/api/upload-images/upload-image';

const beforeUpload = (file) => {
  const isJpgOrPng = file.type === 'image/jpeg' || file.type === 'image/png';
  if (!isJpgOrPng) {
    message.error('You can only upload JPG/PNG file!');
  }
  const isLt2M = file.size / 1024 / 1024 < 2;
  if (!isLt2M) {
    message.error('Image must be smaller than 2MB!');
  }
  return isJpgOrPng && isLt2M;
};

const UploadCover = ({ url, setFieldsValue }) => {
  const [loading, setLoading] = useState(false);
  const [imageUrl, setImageUrl] = useState(null);

  useEffect(() => {
    setImageUrl(url);
  }, [url]);

  const uploadImageMutation = useUploadImageMutation({
    mutationConfig: {
      onSuccess: (data) => {
        message.success('Upload successfully!');
        setImageUrl(data?.url);
        setFieldsValue(data?.url);
      },
      onError: () => {
        message.error('Upload failed!');
      },
      onSettled: () => {
        setLoading(false);
      },
    },
  });

  const handleChange = (info) => {
    if (info.file.status === 'uploading') {
      setLoading(true);
      return;
    }
    if (info.file.status === 'done' && info.file.originFileObj) {
      uploadImageMutation.mutate(info.file.originFileObj);
    }
  };

  const handleRemove = () => {
    setImageUrl(null);
  };

  const uploadButton = (
    <button className="border-none border-0 bg-none bg-0" type="button">
      {loading ? <LoadingOutlined /> : <PlusOutlined />}
      {<div className="ant-upload-text">{loading ? 'Uploading' : 'Upload'}</div>}
    </button>
  );

  return (
    <Space direction="vertical" className="w-full">
      <Upload
        name="avatar"
        listType="picture-card"
        showUploadList={false}
        beforeUpload={beforeUpload}
        onChange={handleChange}
        customRequest={({ onSuccess }) => onSuccess('ok')} // Chặn request mặc định của `Upload`
        rootClassName="upload-cover"
      >
        {imageUrl ? <img src={imageUrl} onClick={(e) => e.stopPropagation()} /> : uploadButton}
      </Upload>
      {imageUrl && (
        <Button color="danger" variant="filled" size="small" onClick={handleRemove} icon={<DeleteOutlined />}>
          Remove Cover
        </Button>
      )}
    </Space>
  );
};

export default UploadCover;

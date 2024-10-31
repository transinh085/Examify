import { useState } from 'react';
import { LoadingOutlined, PlusOutlined } from '@ant-design/icons';
import { Image, message, Upload } from 'antd';
import { useUploadImageMutation } from '~/features/quiz/api/upload-image';

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

const UploadCover = () => {
  const [loading, setLoading] = useState(false);
  const [imageUrl, setImageUrl] = useState(null);
  const [previewOpen, setPreviewOpen] = useState(false);

  const uploadImageMutation = useUploadImageMutation({
    mutationConfig: {
      onSuccess: (data) => {
        message.success('Upload successfully!');
        setLoading(false);
        setImageUrl(data?.url); // giả sử `imageUrl` là đường dẫn ảnh trong response
      },
      onError: () => {
        message.error('Upload failed!');
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

  const uploadButton = (
    <button className="border-none border-0 bg-none bg-0" type="button">
      {loading ? <LoadingOutlined /> : <PlusOutlined />}
      <div className="mt-2">Upload Cover</div>
    </button>
  );

  return (
    <Upload
      name="avatar"
      listType="picture-card"
      className="avatar-uploader"
      showUploadList={false}
      beforeUpload={beforeUpload}
      onChange={handleChange}
      customRequest={({ onSuccess }) => onSuccess('ok')} // Chặn request mặc định của `Upload`
      rootClassName="upload-cover"
    >
      {imageUrl ? (
        <Image
          preview={{
            visible: previewOpen,
            onVisibleChange: (visible) => setPreviewOpen(visible),
            afterOpenChange: (visible) => !visible && setImageUrl(''),
          }}
          src={imageUrl}
        />
      ) : (
        uploadButton
      )}
    </Upload>
  );
};

export default UploadCover;

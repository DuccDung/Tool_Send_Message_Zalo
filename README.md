# ToolSendMessage (WinForms) — Auto gửi tin nhắn Zalo Web bằng Selenium

## 1) Giới thiệu
`ToolSendMessage` là ứng dụng **Windows Forms (C#)** dùng **Selenium WebDriver** để tự động thao tác trên **Zalo Web (https://chat.zalo.me/)** thông qua trình duyệt **CocCoc**.

Ứng dụng hỗ trợ:
- Mở Zalo Web bằng **profile riêng** (để login 1 lần và giữ session)
- Nhập **SĐT** + **nội dung tin nhắn**
- Tự động click các nút trên UI để:
  - Mở form thêm bạn / tìm kiếm
  - Nhập SĐT
  - Nhấn “Tìm kiếm”
  - Nhấn “Nhắn tin”
  - Gõ nội dung và nhấn “Gửi”

---

## 2) Công nghệ sử dụng
- **.NET WinForms**: xây dựng giao diện desktop (Form, Button, TextBox, Label…)
- **Selenium WebDriver**:
  - `OpenQA.Selenium`
  - `OpenQA.Selenium.Chrome`
  - `WebDriverWait` (explicit wait)
- **CocCoc Browser** (Chromium-based)
- **JavaScriptExecutor**:
  - fallback click khi bị intercept/overlay
  - scrollIntoView & focus để input ổn định hơn
- **async/await + Task.Run**:
  - chạy thao tác Selenium ở background để UI không bị treo

---

## 3) Cách hoạt động (Workflow)

### 3.1 Mở Zalo Web bằng profile riêng (btnOpen)
Khi bấm **Open**:
1. Khởi tạo `ChromeOptions`
2. Chỉ định đường dẫn CocCoc:
   - `options.BinaryLocation = "C:\\Program Files\\CocCoc\\Browser\\Application\\browser.exe"`
3. Dùng profile riêng cho Selenium (giữ đăng nhập):
   - `--user-data-dir=C:\ZaloCocCocProfile`
   - `--profile-directory=Default` (tuỳ chọn)
4. Tạo `ChromeDriver`, `WebDriverWait`
5. Điều hướng đến `https://chat.zalo.me/`
6. Nếu là lần đầu, người dùng **login thủ công 1 lần** trong cửa sổ trình duyệt đó  
7. Bật nút **Send**

**Mục tiêu của profile riêng:** không phụ thuộc vào profile CocCoc cá nhân, tránh bị đăng xuất liên tục.

---

### 3.2 Gửi tin nhắn (btnSend)
Khi bấm **Send**:
1. Validate input:
   - `txtPhone` không rỗng
   - `txtMessage` không rỗng
2. Chạy luồng thao tác UI (trong `Task.Run`) theo thứ tự:
   - Click nút mở chức năng “Thêm bạn / Add friend”
   - Nhập SĐT vào ô input
   - Click “Tìm kiếm”
   - Click “Nhắn tin”
   - Focus vào ô chat (`div#input_line_0`) và nhập message
   - Click nút “Gửi”
3. Cập nhật trạng thái trên UI (`lblStatus`)

---

## 4) Các hàm tiện ích chính

### 4.1 WaitVisible(By, seconds)
- Dùng `WebDriverWait` để đợi element xuất hiện và `Displayed = true`
- Giảm lỗi do UI load chậm

### 4.2 ClickSafe(IWebElement)
- Ưu tiên click bình thường
- Nếu bị lỗi (overlay/intercept), fallback sang click bằng JS:
  - `ExecuteScript("arguments[0].click()", el)`

### 4.3 TypePhoneNumber(string phone)
- Tìm input bằng selector: `input[data-id='txt_Main_AddFrd_Phone']`
- `scrollIntoView` + `focus` trước khi nhập
- `Clear()` rồi `SendKeys(phone)`

---

## 5) Yêu cầu môi trường
- Windows 10/11
- Visual Studio (khuyến nghị 2022)
- .NET (tuỳ theo target framework của project)
- CocCoc cài đúng path:
  - `C:\Program Files\CocCoc\Browser\Application\browser.exe`
- ChromeDriver/Selenium tương thích với Chromium version của CocCoc  
  (Nếu mismatch có thể gặp lỗi khi khởi tạo driver)

---

## 6) Cách chạy
1. Build và chạy project WinForms
2. Bấm **Open**
3. Nếu lần đầu:
   - đăng nhập Zalo Web trong cửa sổ CocCoc được mở bằng profile `C:\ZaloCocCocProfile`
4. Nhập:
   - **Phone**
   - **Message**
5. Bấm **Send** để gửi

---

## 7) Lưu ý quan trọng
- UI Zalo Web có thể thay đổi, khi đó các selector XPath/CSS có thể cần cập nhật.
- Nếu gặp lỗi `Timeout: không tìm thấy element`, hãy inspect lại element trên UI hiện tại.
- Không khuyến nghị dùng để gửi hàng loạt / spam. Chỉ nên dùng cho mục đích được phép và có sự đồng ý của người nhận.

---

## 8) Đóng ứng dụng
Khi form đóng, chương trình gọi `_driver?.Quit()` để tắt phiên driver, giải phóng tài nguyên.

---

## 9) Định hướng nâng cấp (tuỳ chọn)
- Import danh sách từ Excel (Phone + Message) để gửi theo batch
- Thêm log chi tiết theo từng dòng (Success/Fail + reason)
- Thêm cơ chế dừng (Cancel) và delay giữa các lần gửi
- Thêm cấu hình selector từ file (để update dễ hơn khi UI đổi)

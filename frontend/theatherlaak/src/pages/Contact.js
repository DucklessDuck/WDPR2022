import React from "react";

const Contact = () => {
  return (
    <div>
      <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
      <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
      <h3>Contact</h3>

      <div class="container contact-form">
        <div class="contact-image">
          <img src="" alt="contact_TheatherLaak" />
        </div>
        <form method="post">
          <h3>Laat een bericht achter!</h3>
          <div class="row">
            <div class="col-md-6">
              <div class="form-group">
                <input type="text" name="txtName" class="form-control" placeholder="Your Name *" value="" />
              </div>
              <div class="form-group">
                <input type="text" name="txtEmail" class="form-control" placeholder="Your Email *" value="" />
              </div>
              <div class="form-group">
                <input type="text" name="txtPhone" class="form-control" placeholder="Your Phone Number *" value="" />
              </div>
            </div>
            <div class="col-md-6">
              <div class="form-group">
                <textarea name="txtMsg" class="form-control" placeholder="Your Message *"></textarea>
              </div>
              <div class="form-group">
                <input type="submit" name="btnSubmit" class="btnContact" value="Send Message" />
              </div>
            </div>
          </div>
        </form>
      </div>
    </div>
  )};

export default Contact;